import { Controller } from 'react-hook-form';
import { Col, Input, InputProps, Label, Row } from 'reactstrap';

import ErrorValidationMessages from '../ErrorValidationMessages';
import { useState } from 'react';
import VemFromGroup from '../VemFormGroup';
import { Eye, EyeOff } from 'react-feather';
import className from 'classnames/bind';
import styles from './VemInput.module.scss';
import VemFragment from '../VemFragment';

const cx = className.bind(styles);

interface VemInputTypes extends InputProps {
  name: string;
  control?: any;
  disabled?: boolean;
  errors?: string[];
  label?: string;
  formGroup?: boolean;
  labelStyle?: string;
  wrapperInputStyle?: string;
  errorStyle?: string;
  onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
  value?: any;
}

interface CustomProps {
  onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
  value?: any;
}

const VemInput = ({
  name,
  control,
  disabled = false,
  errors,
  label,
  formGroup,
  labelStyle = 'col-sm-5 labelInput',
  wrapperInputStyle = 'col-sm-7',
  errorStyle,
  type,
  onChange,
  value,
  ...restProps
}: VemInputTypes) => {
  const [passwordVisible, setPasswordVisible] = useState(false);
  const HasFormGroupElement = formGroup ? VemFromGroup : VemFragment;
  const WrapperInputElement = type === 'checkbox' || type === 'radio' ? VemFragment : Col;
  const WrapperInputPasswordElement = type === 'password' ? 'div' : VemFragment;

  const customProps: CustomProps = {};

  if (onChange !== undefined) {
    customProps.onChange = onChange!;
  }
  if (value !== undefined) {
    customProps.value = value;
  }

  return (
    <HasFormGroupElement row>
      {label && type !== 'checkbox' && type !== 'radio' && (
        <Label
          for={name}
          className={labelStyle}
        >
          {label}
        </Label>
      )}

      <WrapperInputElement
        sm={label ? 12 : 12}
        className={wrapperInputStyle}
      >
        <WrapperInputPasswordElement className={cx('password-input-container')}>
          {control ? (
            <Controller
              name={name}
              control={control}
              disabled={disabled}
              rules={{ required: true }}
              render={({ field }) => (
                <Input
                  className={cx('password-input')}
                  id={name}
                  {...restProps}
                  {...field}
                  {...customProps}
                  type={passwordVisible ? 'text' : type}
                  invalid={
                    errors?.length! > 0 && errors?.[0] !== undefined && errors?.[0] !== ''
                  }
                />
              )}
            />
          ) : (
            <Input
              className={cx('password-input')}
              disabled={disabled}
              id={name}
              {...restProps}
              {...customProps}
              type={passwordVisible ? 'text' : type}
              invalid={
                errors?.length! > 0 && errors?.[0] !== undefined && errors?.[0] !== ''
              }
            />
          )}

          {type === 'password' &&
            (passwordVisible ? (
              <EyeOff
                className={cx(errors?.[0] ? 'me-5' : 'me-0', 'password-toggle-button')}
                size={16}
                onClick={() => setPasswordVisible(!passwordVisible)}
              />
            ) : (
              <Eye
                className={errors?.[0] ? 'me-5' : 'me-0'}
                size={16}
                onClick={() => setPasswordVisible(!passwordVisible)}
              />
            ))}
        </WrapperInputPasswordElement>
      </WrapperInputElement>

      {label && (type === 'checkbox' || type === 'radio') && (
        <Label
          for={name}
          className='ms-2'
        >
          {label}
        </Label>
      )}
      <Row>
        {label && <Col className={labelStyle}></Col>}

        <Col
          className={
            type === 'checkbox' || type === 'radio'
              ? 'col-sm-12'
              : '' || label
                ? wrapperInputStyle
                : 'col-sm-12'
          }
        >
          {errors && <ErrorValidationMessages messages={errors} />}
        </Col>
      </Row>
    </HasFormGroupElement>
  );
};

export default VemInput;
