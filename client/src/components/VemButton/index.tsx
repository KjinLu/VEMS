import { ReactNode } from 'react';
import classNames from 'classnames/bind';

import styles from './VemButton.module.scss';
import { Button, ButtonBaseProps } from '@mui/material';
import { LoadingButton } from '@mui/lab';

interface VemButtonProps extends ButtonBaseProps {
  classes?: string;
  // id: string;
  color?: 'inherit' | 'primary' | 'secondary' | 'success' | 'warning' | 'info' | 'error';
  disabled?: boolean;
  startIcon?: ReactNode;
  endIcon?: ReactNode;
  fullWidth?: boolean;
  href?: string;
  size?: 'small' | 'medium' | 'large';
  variant?: 'contained' | 'outlined' | 'text';
  onClick?: () => void;
  type: 'button' | 'submit' | 'reset';
  status?: 'loading' | 'unloading';
  loading?: boolean;
  children: ReactNode;

  className?: string;
  style?: React.CSSProperties;
}

const cx = classNames.bind(styles);

const VemButton = ({
  classes,
  color = undefined,
  disabled = false,
  // id,
  startIcon,
  endIcon,
  fullWidth,
  href,
  size = 'medium',
  variant = 'text',
  onClick,
  type = 'button',
  status = 'unloading',
  loading = false,
  children,
  ...restProps
}: VemButtonProps) => {
  return (
    <>
      {status === 'unloading' ? (
        <Button
          // id={id}
          classes={classes}
          color={color}
          disabled={disabled}
          startIcon={startIcon}
          endIcon={endIcon}
          fullWidth={fullWidth}
          href={href}
          size={size}
          variant={variant}
          onClick={onClick}
          type={type}
          {...restProps}
          className={cx(`${restProps.className}`)}
        >
          {children}
        </Button>
      ) : (
        <LoadingButton
          // id={id}
          classes={classes}
          color={color}
          disabled={disabled}
          startIcon={startIcon}
          endIcon={endIcon}
          fullWidth={fullWidth}
          href={href}
          size={size}
          variant={variant}
          onClick={onClick}
          type={type}
          loading={loading}
          {...restProps}
          className={cx('button', `${restProps.className}`)}
        >
          {children}
        </LoadingButton>
      )}
    </>
  );
};

export default VemButton;
