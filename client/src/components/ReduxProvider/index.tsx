import { Provider } from 'react-redux';

import { ReactNode } from 'react';
import { store } from '@/libs/state/store';

interface ReduxProviderProps {
  children: ReactNode;
}

const ReduxProvider = ({ children }: ReduxProviderProps) => {
  return <Provider store={store}>{children}</Provider>;
};

export default ReduxProvider;
