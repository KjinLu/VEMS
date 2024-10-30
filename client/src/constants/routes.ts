export const configRoutes = {
  home: '/admin',
  profile: '/profile',
  upload: '/upload',
  search: '/search',
  login: '/login',
  forgetPassword: '/forget-password',
  signUp: '/signUp',

  // Web management
  ScheduleManagementPage: '/schedule-management',
  StudentManagementPage: '/student-management',
  TeacherManagementPage: '/teacher-management',
  ClassManagementPage: '/class-management',

  //Student
  studentSchedule: '/student/schedule',
  studentAttendanceSchedule: '/student/attendance',
  studentViewAttendance: '/student/attendance-report',
  studentTakeAttendance: '/student/attendance/take',
  studentEditAttendance: '/student/attendance/edit',

  //Teacher
  teacherSchedule: '/teacher/schedule',
  teacherAttendanceSchedule: '/teacher/attendance',
  teacherViewAttendance: '/teacher/attendance-report',
  teacherTakeAttendance: '/teacher/attendance/take',
  teacherEditAttendance: '/teacher/attendance/edit',
  teacherClassManagement: '/teacher/class-management'
};

export const configError = {
  NotFound: '/notfound',
  UnAuthorize: '/unauthorize',
  Network: '/network'
};

export const configAuthorise = {
  matcher: ['/admin/:path*', '/student/:path*', '/teacher/:path*']
};
