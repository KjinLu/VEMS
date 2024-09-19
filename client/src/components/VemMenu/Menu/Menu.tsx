import Tippy from '@tippyjs/react/headless';
import classNames from 'classnames/bind';
import styles from './Menu.module.scss';
import Header from './Header';

import MenuItem from './MenuItem';
import Wrapper from '../Wrapper';
import { ReactElement, useState } from 'react';

type itemsProps = {
  icon: ReactElement;
  title: string;
  to: string;
  separate: boolean;
  children: ReactElement;
};

type MenuProps = {
  children: ReactElement;
  items: itemsProps[];
  hideOnClick?: boolean;
  onChange: (e: any) => {};
};

const cx = classNames.bind(styles);

const Menu = ({ children, items = [], hideOnClick = false, onChange }: MenuProps) => {
  const [history, setHistory] = useState([{ data: items }]);
  const current: any = history[history.length - 1];

  const renderItems = () => {
    return current.data.map((item: any, index: any) => {
      const isParent = !!item.children;

      return (
        <MenuItem
          key={index}
          data={item}
          onClick={() => {
            if (isParent) {
              setHistory(prev => [...prev, item.children]);
            } else {
              onChange(item);
            }
          }}
        />
      );
    });
  };

  const handleBack = () => {
    setHistory(prev => prev.slice(0, prev.length - 1));
  };

  const renderResult = (attrs: any) => (
    <div
      className={cx('menu-list')}
      tabIndex='-1'
      {...attrs}
    >
      <Wrapper className={cx('menu-popper')}>
        {history.length > 1 && (
          <Header
            title={current.title}
            onClick={handleBack}
          />
        )}
        <div className={cx('menu-body')}>{renderItems()}</div>
      </Wrapper>
    </div>
  );

  const handleResetToFirstPage = () => {
    setHistory(prev => prev.slice(0, 1));
  };

  return (
    <Tippy
      interactive
      delay={[0, 500]}
      offset={[12, 8]}
      // click vào avatar không ẩn menu
      hideOnClick={hideOnClick}
      // placement để chỉnh vị trí
      placement='bottom-end'
      render={renderResult}
      onHide={handleResetToFirstPage}
    >
      {children}
    </Tippy>
  );
};

export default Menu;
