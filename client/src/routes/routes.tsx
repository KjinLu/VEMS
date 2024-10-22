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
import ScheduleManagementPage from '@/pages/WebManagement/ScheduleManagementPage';
import NotFound from '@/pages/Error/NotFound';
import Authorize from '@/pages/Error/Authorize';
import Network from '@/pages/Error/Network';
import StudentAttendanceReportPage from '@/pages/StudentAttendanceReport';

import StudentManagementPage from '@/pages/WebManagement/StudentManagementPage';
import TeacherManagementPage from '@/pages/WebManagement/TeacherManagementPage';
import StudentTakeAttendanceSchedulePage from '@/pages/StudentAttendanceSchedule';
import StudentTakeAttendancePage from '@/pages/StudentTakeAttendance';
import StudentUpdateAttendancePage from '@/pages/StudentUpdateAttendance';

const publicRoutes: PublicRoute[] = [
  { path: configRoutes.login, component: Login, layout: AuthLayout },

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
    path: configRoutes.ScheduleManagementPage,
    component: ScheduleManagementPage,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN'],
    isAuthenticated: true
  },
  {
    path: configRoutes.StudentManagementPage,
    component: StudentManagementPage,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN'],
    isAuthenticated: true
  },
  {
    path: configRoutes.TeacherManagementPage,
    component: TeacherManagementPage,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN'],
    isAuthenticated: true
  },
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
    layout: DefaultLayout,
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
    path: configRoutes.studentAttendanceSchedule,
    component: StudentTakeAttendanceSchedulePage,
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
    path: configRoutes.studentEditAttendance,
    component: StudentUpdateAttendancePage,
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
