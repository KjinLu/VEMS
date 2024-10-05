import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';

import App from './App.tsx';
import GlobalStyles from './styles/GlobalStyles/index.tsx';
import ReduxProvider from './components/ReduxProvider/index.tsx';
import CustomThemeProvider from './components/ThemeMUIProvider/index.tsx';
import { ConfigProvider } from 'antd';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <CustomThemeProvider>
      <ConfigProvider theme={{ hashed: false }}>
        <ReduxProvider>
          <GlobalStyles>
            <App />
          </GlobalStyles>
        </ReduxProvider>
      </ConfigProvider>
    </CustomThemeProvider>
  </StrictMode>
);
