import { configError, configRoutes } from '@/constants/routes';

//Layout
import HeaderOnly from '@/layouts/HeaderOnly';
import AuthLayout from '@/layouts/AuthLayout';

import Home from '@/pages/Home';
import Profile from '@/pages/Profile';
import StudentSchedule from '@/pages/StudentSchedule';
import Login from '@/pages/Login';
import DefaultLayout from '@/layouts/DefaultLayout';
import { PrivateRoute, PublicRoute } from '@/types/components/route';
import ScheduleManagementPage from '@/pages/ScheduleManagementPage';
import NotFound from '@/pages/Error/NotFound';
import Authorize from '@/pages/Error/Authorize';
import Network from '@/pages/Error/Network';
import StudentTakeAttendancePage from '@/pages/StudentTakeAttendance';
import StudentAttendanceReportPage from '@/pages/StudentAttendanceReport';
import StudentManagementPage from '@/pages/StudentManagementPage';
import TeacherManagementPage from '@/pages/TeacherManagementPage';

const publicRoutes: PublicRoute[] = [
  { path: configRoutes.login, component: Login, layout: AuthLayout },
  {
    path: configRoutes.ScheduleManagementPage,
    component: ScheduleManagementPage,
    layout: DefaultLayout
  },
  {
    path: configRoutes.StudentManagementPage,
    component: StudentManagementPage,
    layout: DefaultLayout
  },
  {
    path: configRoutes.TeacherManagementPage,
    component: TeacherManagementPage,
    layout: DefaultLayout
  },
  {
    path: configError.NotFound,
    component: NotFound
  },
  {
    path: configError.UnAuthorize,
    component: Authorize
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
