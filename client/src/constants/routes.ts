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

  // Web management
  ScheduleManagementPage: '/schedule-management',
  StudentManagementPage: '/student-management',
  TeacherManagementPage: '/teacher-management',
  ClassManagementPage: '/class-management'
};

export const configError = {
  NotFound: '/notfound',
  UnAuthorize: '/unauthorize',
  Network: '/network'
};

export const configAuthorise = {
  matcher: ['/admin/:path*', '/student/:path*', '/teacher/:path*']
};
