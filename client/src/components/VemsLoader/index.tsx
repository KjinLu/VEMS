import className from 'classnames/bind';

import styles from './VemLoader.module.scss';

const cx = className.bind(styles);

type VemLoaderProps = {
  useFor?: 'loginButton' | 'component' | 'form';
};

const VemsLoader = (props: VemLoaderProps) => {
  return props.useFor === 'form' ? (
    <div className={cx('loading-overlay')}>
      <div
        className={cx('spinner-border text-primary')}
        role='status'
      ></div>
    </div>
  ) : (
    <div className={cx('loader-wrapper', `${props.useFor ? props.useFor : 'component'}`)}>
      <div className={cx('loading-container')}>
        <div className={cx('loading-rotate')}>
          <div className={cx('rotate-item')}></div>
        </div>
      </div>
    </div>
  );
};
export default VemsLoader;
