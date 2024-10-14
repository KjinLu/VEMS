import { configRoutes } from '@/constants/routes';

//Layout
import HeaderOnly from '@/layouts/HeaderOnly';
import AuthLayout from '@/layouts/AuthLayout';

import Home from '@/pages/Home';
import Profile from '@/pages/Profile';
import Upload from '@/pages/Upload';
import Search from '@/pages/Search';
import SignIn from '@/pages/SignIn';
import SignUp from '@/pages/SignUp';
import DefaultLayout from '@/layouts/DefaultLayout';
import { PrivateRoute, PublicRoute } from '@/types/components/route';

const publicRoutes : PublicRoute[] = [
  { path: configRoutes.signIn, component: SignIn, layout: AuthLayout },
  { path: configRoutes.signUp, component: SignUp, layout: AuthLayout },
  { path: configRoutes.home, component: Home, layout: DefaultLayout }
];

const privateRoutes : PrivateRoute[] = [
  { path: configRoutes.home, component: Home, role: ['ADMIN'] },
  {
    path: configRoutes.profile,
    component: Profile,
    role: ['ADMIN', 'TEACHER', 'STUDENT']
  },
  { path: configRoutes.upload, component: Upload, layout: HeaderOnly, role: ['ADMIN'] },
  { path: configRoutes.search, component: Search, layout: null, role: ['ADMIN'] }
];

export { publicRoutes, privateRoutes };
