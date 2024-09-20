import configRoutes from '../constants/routes';

//Layout
import HeaderOnly from '../layouts/HeaderOnly';

import Home from '../pages/Home';
import Profile from '../pages/Profile';
import Upload from '../pages/Upload';
import Search from '../pages/Search';
import Login from '../pages/Login';
const publicRoutes = [
  { path: configRoutes.login, component: Login, layout: null }
];

const privateRoutes = [
  { path: configRoutes.home, component: Home, role: ["admin"] },
  { path: configRoutes.profile, component: Profile, role: ["admin", "teacher", "student"] },
  { path: configRoutes.upload, component: Upload, layout: HeaderOnly, role: ["admin"] },
  { path: configRoutes.search, component: Search, layout: null, role: ["admin"] }
];

export { publicRoutes, privateRoutes };
