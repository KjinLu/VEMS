export function formatDate(isoString: string): string {
  const date = new Date(isoString);
  const day = date.getDate().toString().padStart(2, '0');
  const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Tháng tính từ 0
  const year = date.getFullYear();

  return `${day}-${month}-${year}`;
}

export function convertDayOfWeek(dayOfWeek: number): string {
  const daysOfWeek = ['Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6', 'Thứ 7', 'Chủ Nhật'];

  return daysOfWeek[dayOfWeek - 1] || 'Không hợp lệ';
}

export const isAttendanceDateInThePast = (attendanceDate: string | Date): boolean => {
  const currentDate = new Date();
  const attendanceTime = new Date(attendanceDate);

  // So sánh chỉ ngày, bỏ qua giờ, phút, giây
  currentDate.setHours(0, 0, 0, 0);
  attendanceTime.setHours(0, 0, 0, 0);

  return attendanceTime <= currentDate;
};
