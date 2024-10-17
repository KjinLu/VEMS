export const configRoutes = {
  home: '/admin',
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
