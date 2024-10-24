import { ReactElement } from 'react';

import Header from '../components/Header';

type HeaderOnlyProps = {
  children: ReactElement;
};

const HeaderOnly = ({ children }: HeaderOnlyProps) => {
  return (
    <div>
      <Header />
      <div className='container'>
        <div className='content'>{children}</div>
      </div>
    </div>
  );
};

export default HeaderOnly;
