import { useState, forwardRef } from 'react';
import NoImage from '../../assets/no-image.png';
import styles from './Image.module.scss';
import classNames from 'classnames';

type ImageProps = {
  src: string;
  alt: string;
  className: string;
  fallback: string;
};

const VemImage = (
  { src, alt, className, fallback: customFallback = NoImage, ...props }: ImageProps,
  ref: React.LegacyRef<HTMLImageElement>
) => {
  const [fallback, setFallBack] = useState('');

  const handleError = () => {
    setFallBack(customFallback);
  };

  return (
    <img
      className={classNames(styles.wrapper, className)}
      ref={ref}
      src={fallback || src}
      alt={alt}
      {...props}
      onError={handleError}
    />
  );
};

export default forwardRef(VemImage);
