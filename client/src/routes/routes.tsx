import configRoutes from '../constants/routes';

//Layout
import HeaderOnly from '../layouts/HeaderOnly';

import Home from '../pages/Home';
import Profile from '../pages/Profile';
import Upload from '../pages/Upload';
import Search from '../pages/Search';
import Login from '../pages/Login';

const publicRoutes = [
  { path: configRoutes.home, component: Home },
  { path: configRoutes.profile, component: Profile },
  { path: configRoutes.upload, component: Upload, layout: HeaderOnly },
  { path: configRoutes.search, component: Search, layout: null },
  { path: configRoutes.login, component: Login, layout: null }
];

const privateRoutes = [];

export { publicRoutes, privateRoutes };
