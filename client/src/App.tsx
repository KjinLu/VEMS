import { BrowserRouter, Route, Routes } from 'react-router-dom';
import ProtectedRoutes from './helpers/ProtectedRoutes';
import { useSelector } from 'react-redux';
import { RootState } from './libs/state/store';
import { Role } from './types/auth/type';

const App = () => {
  const allowedRoles = useSelector((state: RootState) => state.auth.role as Role);

  return (
    <BrowserRouter>
      <div className='App'>
        <ProtectedRoutes
          isAuthenticated={true}
          allowedRoles={[allowedRoles]}
        />
      </div>
    </BrowserRouter>
  );
};

export default App;
