export const configRoutes = {
  home: '/admin',
  student: '/student',
  profile: '/:nickname',
  upload: '/upload',
  search: '/search',
  signIn: '/login',
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
