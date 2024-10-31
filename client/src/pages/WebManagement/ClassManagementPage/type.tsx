export type ClassIndex = {
  index: number;
  id: string;
  className: string;
  gradeId: string;
  numberOfStudents: string;
  primaryTeacherID: string;
  primaryTeacherName: string;
};

export type ClassListProps = {
  data: ClassIndex[];
};
