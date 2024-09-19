import {
  faCircleQuestion,
  faCoins,
  faEarthAsia,
  faEllipsisVertical,
  faGear,
  faKeyboard,
  faSignOut,
  faUser
} from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import classNames from 'classnames/bind';
import Tippy from '@tippyjs/react';
import 'tippy.js/dist/tippy.css';
import { Link } from 'react-router-dom';

import Logo from '../../../assets/react.svg';
import styles from './Header.module.scss';
import Menu from '../../../components/VemMenu';
import { MessageIcon } from '../../../components/Icons/index';
import VemImage from '../../../components/VemImage';

// Cấu hình routers
import routes from '../../../constants/routes';

const cx = classNames.bind(styles);

const MENU_ITEMS = [
  {
    icon: <FontAwesomeIcon icon={faEarthAsia} />,
    title: 'English',
    children: {
      title: 'Language',
      data: [
        {
          type: 'language',
          code: 'en',
          title: 'English'
        },
        {
          type: 'language',
          code: 'vi',
          title: 'Tiếng việt'
        }
      ]
    }
  },
  {
    icon: <FontAwesomeIcon icon={faCircleQuestion} />,
    title: 'Feedback and help',
    to: '/feedback'
  },
  {
    icon: <FontAwesomeIcon icon={faKeyboard} />,
    title: 'Keyboard shortcuts'
  }
];

function Header() {
  const currentUser = true;

  //Handle logic
  const handleMenuChange = (menuItem: any) => {
    switch (menuItem.type) {
      case 'language':
        //Handle change language
        break;
      default:
    }
  };

  const userMenu = [
    {
      icon: <FontAwesomeIcon icon={faUser} />,
      title: 'View profile',
      to: '/@hoa'
    },
    {
      icon: <FontAwesomeIcon icon={faCoins} />,
      title: 'Get coins',
      to: '/coin'
    },
    {
      icon: <FontAwesomeIcon icon={faGear} />,
      title: 'Settings',
      to: '/settings'
    },
    ...MENU_ITEMS,
    {
      icon: <FontAwesomeIcon icon={faSignOut} />,
      title: 'Log out',
      to: '/logout',
      separate: true
    }
  ];

  return (
    <header className={cx('wrapper')}>
      <div className={cx('inner')}>
        <Link
          to={routes.home}
          className={cx('logo-link')}
        >
          <img
            src={Logo}
            alt='TikTok'
          />
        </Link>

        <div className={cx('actions')}>
          {currentUser ? (
            <>
              <Tippy
                delay={[0, 50]}
                content='Message'
                placement='bottom'
              >
                <button className={cx('action-btn')}>
                  <MessageIcon />
                </button>
              </Tippy>
            </>
          ) : (
            <></>
          )}

          <Menu
            items={currentUser ? userMenu : MENU_ITEMS}
            onChange={handleMenuChange}
          >
            {currentUser ? (
              <VemImage
                src='htts://p16-sign-sg.tiktokcdn.com/aweme/100x100/tos-alisg-avt-0068/9ee78c188f1c700711f3cdddfbcdbb2c.jpeg?lk3s=a5d48078&x-expires=1712664000&x-signature=MKnxUgvODE6peEpDknedHWEprdQ%3D'
                className={cx('user-avatar')}
                alt='avatarUser'
                // truyền ảnh muốn thay thế khi mà link ảnh gốc bị lỗi
                fallback='https://p9-sign-sg.tiktokcdn.com/aweme/100x100/tos-alisg-avt-0068/2946bb5ae44e7022b0f86ab1c50672c0.jpeg?lk3s=a5d48078&x-expires=1712696400&x-signature=WhZ%2FU3q4fUjwpiECenS7FseDtpk%3D'
              />
            ) : (
              <></>
            )}
          </Menu>
        </div>
      </div>
    </header>
  );
}

export default Header;
