export type ClassInfo = {
  classID: string;
  className: string;
  numberOfStudent: number;
  students: ClassStudent[];
};

export type ClassStudent = {
  studentID: string;
  PublicStudentID: string;
  className: string;
  studentName: string;
  studentImage: string;
  studentPhone: string;
  studentType: string;
  studentTypeID: string;
};

export type ClassStudentWithIndex = ClassStudent & { index: number };
