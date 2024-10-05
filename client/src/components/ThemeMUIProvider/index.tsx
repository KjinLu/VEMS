import { CssBaseline } from '@mui/material';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { ReactNode } from 'react';
const theme = createTheme({
  typography: {
    fontSize: 14
  }
});

interface ThemeProviderProps {
  children: ReactNode;
}

const CustomThemeProvider = ({ children }: ThemeProviderProps) => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      {children}
    </ThemeProvider>
  );
};

export default CustomThemeProvider;
