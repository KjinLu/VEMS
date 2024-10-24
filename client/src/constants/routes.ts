export const configRoutes = {
  home: '/admin',
  studentSchedule: '/student/schedule',
  studentAttendanceSchedule: '/student/attendance',
  studentViewAttendance: '/student/attendance-report',
  studentTakeAttendance: '/student/attendance/take',
  studentEditAttendance: '/student/attendance/edit',
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
