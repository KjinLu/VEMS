import { configError, configRoutes } from '@/constants/routes';
//Layout
import HeaderOnly from '@/layouts/HeaderOnly';
import AuthLayout from '@/layouts/AuthLayout';

import Home from '@/pages/Home';
import Profile from '@/pages/Profile';
import StudentSchedule from '@/pages/StudentSchedule';
import Login from '@/pages/Login';
import ForgetPassword from '@/pages/ForgetPassword';
import DefaultLayout from '@/layouts/DefaultLayout';
import { PrivateRoute, PublicRoute } from '@/types/components/route';
import NotFound from '@/pages/Error/NotFound';
import Authorize from '@/pages/Error/Authorize';
import Network from '@/pages/Error/Network';
import StudentAttendanceReportPage from '@/pages/StudentAttendanceReport';
import StudentTakeAttendanceSchedulePage from '@/pages/StudentAttendanceSchedule';
import StudentTakeAttendancePage from '@/pages/StudentTakeAttendance';
import StudentUpdateAttendancePage from '@/pages/StudentUpdateAttendance';

// Web management
import ScheduleManagementPage from '@/pages/WebManagement/ScheduleManagementPage';
import StudentManagementPage from '@/pages/WebManagement/StudentManagementPage';
import TeacherManagementPage from '@/pages/WebManagement/TeacherManagementPage';
import ClassManagementPage from '@/pages/WebManagement/ClassManagementPage';
import TeacherSchedulePage from '@/pages/TeacherSchedule';
import TeacherEditAttendancePage from '@/pages/TeacherEditAttendance';
import TeacherClassManagementPage from '@/pages/TeacherClassManagement';
import TeacherAttendanceManagementPage from '@/pages/TeacherAttendanceManagement';
import TeacherTakeAttendancePage from '@/pages/TeacherTakeAttendance';

const publicRoutes: PublicRoute[] = [
  { path: configRoutes.login, component: Login, layout: AuthLayout },
  { path: configRoutes.forgetPassword, component: ForgetPassword, layout: AuthLayout },
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
    allowedRoles: ['STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.studentAttendanceSchedule,
    component: StudentTakeAttendanceSchedulePage,
    layout: DefaultLayout,
    allowedRoles: ['STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.studentTakeAttendance,
    component: StudentTakeAttendancePage,
    layout: DefaultLayout,
    allowedRoles: ['STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.studentEditAttendance,
    component: StudentUpdateAttendancePage,
    layout: DefaultLayout,
    allowedRoles: ['STUDENT'],
    isAuthenticated: true
  },
  {
    path: configRoutes.studentViewAttendance,
    component: StudentAttendanceReportPage,
    layout: DefaultLayout,
    allowedRoles: ['STUDENT'],
    isAuthenticated: true
  },
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
    path: configRoutes.ClassManagementPage,
    component: ClassManagementPage,
    layout: DefaultLayout,
    allowedRoles: ['ADMIN'],
    isAuthenticated: true
  },
  {
    path: configRoutes.teacherSchedule,
    component: TeacherSchedulePage,
    layout: DefaultLayout,
    allowedRoles: ['TEACHER'],
    isAuthenticated: true
  },
  {
    path: configRoutes.teacherAttendanceSchedule,
    component: TeacherAttendanceManagementPage,
    layout: DefaultLayout,
    allowedRoles: ['TEACHER'],
    isAuthenticated: true
  },
  {
    path: configRoutes.teacherClassManagement,
    component: TeacherClassManagementPage,
    layout: DefaultLayout,
    allowedRoles: ['TEACHER'],
    isAuthenticated: true
  },
  {
    path: configRoutes.teacherTakeAttendance,
    component: TeacherTakeAttendancePage,
    layout: DefaultLayout,
    allowedRoles: ['TEACHER'],
    isAuthenticated: true
  },
  {
    path: configRoutes.teacherEditAttendance,
    component: TeacherEditAttendancePage,
    layout: DefaultLayout,
    allowedRoles: ['TEACHER'],
    isAuthenticated: true
  }
  // { path: configRoutes.search, component: Search, layout: null, allowedRoles: ['ADMIN'] }
];

export { publicRoutes, privateRoutes };
