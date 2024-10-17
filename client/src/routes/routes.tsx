import { configError, configRoutes } from '@/constants/routes';

//Layout
import HeaderOnly from '@/layouts/HeaderOnly';
import AuthLayout from '@/layouts/AuthLayout';

import Home from '@/pages/Home';
import Profile from '@/pages/Profile';
import Upload from '@/pages/Upload';
import StudentSchedule from '@/pages/StudentSchedule';
import Search from '@/pages/Search';
import SignIn from '@/pages/SignIn';
import DefaultLayout from '@/layouts/DefaultLayout';
import { PrivateRoute, PublicRoute } from '@/types/components/route';
import AdminManagementPage from '@/pages/AdminManagement';
import NotFound from '@/pages/Error/NotFound';
import Authorise from '@/pages/Error/Authorize';
import Network from '@/pages/Error/Network';
import StudentTakeAttendancePage from '@/pages/StudentTakeAttendance';
import StudentAttendanceReportPage from '@/pages/StudentAttendanceReport';

const publicRoutes: PublicRoute[] = [
  { path: configRoutes.signIn, component: SignIn, layout: AuthLayout },
  // { path: configRoutes.signUp, component: SignUp, layout: AuthLayout },
  // { path: configRoutes.home, component: Home, layout: DefaultLayout },
  { path: configRoutes.search, component: Search, layout: DefaultLayout },
  {
    path: configRoutes.AdminManagementPage,
    component: AdminManagementPage,
    layout: DefaultLayout
  },
  {
    path: configError.NotFound,
    component: NotFound
  },
  {
    path: configError.UnAuthorize,
    component: Authorise
  },
  {
    path: configError.Network,
    component: Network
  }
];

const privateRoutes: PrivateRoute[] = [
  {
    path: configRoutes.home,
    component: Home,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN', 'TEACHER', 'STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.profile,
    component: Profile,
    allowedRoles: ['ADMIN', 'TEACHER', 'STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.upload,
    component: Upload,
    layout: HeaderOnly,
    allowedRoles: ['ADMIN', 'TEACHER', 'STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.studentSchedule,
    component: StudentSchedule,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN', 'STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.studentTakeAttendance,
    component: StudentTakeAttendancePage,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN', 'STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.studentViewAttendance,
    component: StudentAttendanceReportPage,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN', 'STUDENT'],
    isAuthenticated: true
  }
  // { path: configRoutes.search, component: Search, layout: null, allowedRoles: ['ADMIN'] }
];

export { publicRoutes, privateRoutes };
