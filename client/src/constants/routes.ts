import StudentSchedulePage from '@/pages/StudentSchedule';

export const configRoutes = {
  home: '/admin',
  studentSchedule: '/student/schedule',
  studentTakeAttendance: '/student/attendance',
  studentViewAttendance: '/student/attendanceReport',
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
