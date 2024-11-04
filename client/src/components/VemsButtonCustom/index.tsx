import { ReactNode } from 'react';
import { Button, ButtonProps } from 'reactstrap';
import VemsLoader from '../VemsLoader';
import classNames from 'classnames/bind';

import styles from './VemsButtonCus.module.scss';

interface VemsButtonProps extends ButtonProps {
  color?: string;
  title: string;
  leftIcon?: ReactNode;
  rightIcon?: ReactNode;
  loading?: boolean;
  onClick?: () => void;
  size?: 'md' | 'sm' | 'lg';
  isCenterIcon?: boolean;
}

const cx = classNames.bind(styles);

const VemsButtonCus = ({
  color,
  title,
  leftIcon,
  rightIcon,
  loading,
  onClick,
  size,
  isCenterIcon = false,
  ...restProps
}: VemsButtonProps) => {
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
          <VemsLoader useFor={'loginButton'} />
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

export default VemsButtonCus;
