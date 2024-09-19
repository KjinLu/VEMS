import { ReactElement } from 'react';

type MenuProps = {
  children: ReactElement;
};

const Menu = ({ children }: MenuProps) => {
  return <nav>{children}</nav>;
};

export default Menu;
