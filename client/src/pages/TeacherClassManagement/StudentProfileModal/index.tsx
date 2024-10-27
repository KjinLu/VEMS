import VemImage from '@/components/VemImage';
import { useEffect, useState } from 'react';
import { FaTimes } from 'react-icons/fa';
import { Col, Modal, ModalBody, ModalHeader, Row } from 'reactstrap';

type ModalProps = {
  isOpen: boolean;
  toggleModal: any;
};

const StudentProfileModal = ({ isOpen, toggleModal }: ModalProps) => {
  const [studentData, setStudentData] = useState<any>();

  return (
    <Row>
      <Modal
        isOpen={isOpen}
        size='lg'
      >
        <Row className='align-items-center p-2'>
          <Col
            sm={11}
            className='text-start'
          >
            <h3>Hồ sơ học sinh</h3>
          </Col>
          <Col
            sm={1}
            className='text-end'
          >
            <FaTimes
              onClick={toggleModal}
              style={{ cursor: 'pointer' }}
            />{' '}
          </Col>
        </Row>
        <Row className='p-3'>
          <Row className='mb-4 align-items-center '>
            <Col
              sm={4}
              className='text-center'
            >
              <VemImage
                alt=''
                className=''
                fallback=''
                src={''}
              />
            </Col>
            <Col sm={8}>
              <Row>
                <h4>{}</h4>
                <p className='text-muted'>
                  {} - {}
                </p>
                <p>
                  <strong>Student ID:</strong> {}
                </p>
                <p>
                  <strong>Username:</strong> {}
                </p>
              </Row>
              <Row>
                <p>
                  <strong>Email:</strong> {'N/A'}
                </p>
                <p>
                  <strong>Phone:</strong> {'N/A'}
                </p>
                <p>
                  <strong>Parent's Phone:</strong> {'N/A'}
                </p>
                <p>
                  <strong>Citizen ID:</strong> {'N/A'}
                </p>
                <p>
                  <strong>Date of Birth:</strong> {'N/A'}
                </p>
                <p>
                  <strong>Union Join Date:</strong> {'N/A'}
                </p>

                <p>
                  <strong>Address:</strong> {'N/A'}
                </p>
                <p>
                  <strong>Hometown:</strong> {'N/A'}
                </p>
              </Row>
            </Col>
          </Row>
        </Row>
      </Modal>
    </Row>
  );
};

export default StudentProfileModal;
