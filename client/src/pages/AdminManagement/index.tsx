import className from 'classnames/bind';
import styles from './AdminManagement.module.scss';

const cx = className.bind(styles);

const AdminManagementPage = () => {
  return (
    <>
      <div>
        <div className={cx('welcome-card')}>
          <h2>Chào mừng đến với hệ thống </h2>
          <p>VEMS 4.0</p>
          {/* <img
            src={require('@assets/imgaes/admin/medal-image.jpg')}
            alt=''
          /> */}
        </div>
      </div>
    </>
  );
};

export default AdminManagementPage;
