import StudentSchedulePage from '@/pages/StudentSchedule';

export const configRoutes = {
  home: '/admin',
  studentSchedule: '/student/schedule',
  studentAttendanceSchedule: '/student/attendance',
  studentViewAttendance: '/student/attendance-report',
  studentTakeAttendance: '/student/attendance/take',
  profile: '/:nickname',
  upload: '/upload',
  search: '/search',
  login: '/login',
  signUp: '/signUp',
  AdminManagementPage: '/admin-management'
};

export const configError = {
  NotFound: '/notfound',
  UnAuthorize: '/unauthorize',
  Network: '/network'
};

export const configAuthorise = {
  matcher: ['/admin/:path*', '/student/:path*', '/teacher/:path*']
};
