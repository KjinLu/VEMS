import { ReactNode } from 'react';
import { Button, ButtonProps } from 'reactstrap';
import classNames from 'classnames/bind';

import VemLoader from '../../components/VemLoader';
import styles from './VemButton.module.scss';

interface VemButtonProps extends ButtonProps {
  color?: string;
  title?: string;
  leftIcon?: ReactNode;
  rightIcon?: ReactNode;
  loading?: boolean;
  onClick?: (e: any) => void;
  size?: 'md' | 'sm' | 'lg';
  isCenterIcon?: boolean;
}

const cx = classNames.bind(styles);

const VemButton = ({
  color,
  title,
  leftIcon,
  rightIcon,
  loading,
  onClick,
  size,
  isCenterIcon = false,
  ...restProps
}: VemButtonProps) => {
  const isIconVisible =
    leftIcon || rightIcon ? 'd-flex justify-content-center align-items-center' : '';
  const centerIconTrue = isCenterIcon
    ? 'd-flex justify-content-center align-items-center'
    : '';
  return (
    <Button
      color={color}
      onClick={onClick}
      {...restProps}
      className={cx('button', `${restProps.className}`)}
    >
      {loading ? (
        <>
          <VemLoader useFor={'loginButton'} />
          <span className={cx(`${size ? size : 'sm'}`)}>{title}</span>
        </>
      ) : (
        <div className={isIconVisible + centerIconTrue}>
          <span className={centerIconTrue}>{leftIcon}</span>
          <span className={cx(`${size ? size : 'md'}`)}>{title}</span>
          <span className={centerIconTrue}>{rightIcon}</span>
        </div>
      )}
    </Button>
  );
};

export default VemButton;
