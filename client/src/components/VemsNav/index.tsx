import classNames from 'classnames/bind';
import { Nav, NavItem, NavLink } from 'reactstrap';
import { ReactElement, useState } from 'react';

import styles from './VemsNav.module.scss';

const cx = classNames.bind(styles);

type TabData = {
  tabId: number;
  tabName: string;
};

type VemsNavProps = {
  tabData: TabData[];
  handleChangeTab: (tabId: number) => void;
  isCapitalizeTitle?: boolean;
  children?: ReactElement;
};

const VemsNav = ({
  tabData,
  handleChangeTab,
  isCapitalizeTitle = true,
  children
}: VemsNavProps) => {
  const [activeTab, setActiveTab] = useState<number>(1);

  return (
    <>
      <Nav tabs>
        {tabData.map(data => (
          <NavItem key={data.tabId}>
            <NavLink
              className={cx('fw-medium', {
                active: activeTab === data.tabId,
                NavTitle: isCapitalizeTitle
              })}
              onClick={() => {
                setActiveTab(data.tabId);
                handleChangeTab(data.tabId);
              }}
            >
              {data.tabName}
            </NavLink>
          </NavItem>
        ))}
      </Nav>
      {children}
    </>
  );
};

export default VemsNav;
