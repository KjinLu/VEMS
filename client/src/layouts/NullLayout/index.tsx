import { ReactElement } from 'react';

type NullLayoutProps = {
  children: ReactElement;
};

const HeaderOnly = ({ children }: NullLayoutProps) => {
  return <>{children}</>;
};

export default HeaderOnly;
