export interface classRoom {
  classRoomId: number
  name: string
  students: student[]
  teachers: teacher[]
}

export interface student {
  id: number;
  firstName: string;
  lastName: string;
  contactPerson: string;
  contactNumber: number;
  email: string;
  dateOfBirth: Date;
  classRoomId: number;
}

export interface subject {
  id: number;
  name: string;
  teachers: teacher[];
}

export interface teacher {
  teacherId: number;
  firstName: string;
  lastName: string;
  contactNumber: number;
  email: string;
  classRooms: classRoom[];
  subjects: subject[];
}