export type Subject = {
  code: string;
  id: string;
  subjectName: string;
};

export type SlotBase = {
  id: string;
  slotIndex: number;
};

export type Session = {
  code: string;
  dayOfWeek: number;
  periodID: string;
  periodName: string;
  sessionID: string;
};

export type Classroom = {
  id: string;
  className: string;
};

export type CreateScheduleRequest = {
  time: string;
  classroomId: string;
};

export type CreateScheduleDetailRequest = {
  scheduleID: string;
  sessions: CreateSessionRequest[];
};

export type CreateSessionRequest = {
  sessionID: string;
  slotDetails: CreateSlotDetailRequest[];
};

export type CreateSlotDetailRequest = {
  subjectID: string;
  teacherID?: string;
  slotID: string;
};
