import {
  Avatar,
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Tab,
  Tabs,
  Typography
} from '@mui/material';
import { FaPen } from 'react-icons/fa';
import React, { useState } from 'react';
import Personal from './components/personal';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import { useGetStudentProfileQuery } from '@/services/profile';
import { Badge } from 'antd';

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function CustomTabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role='tabpanel'
      hidden={value !== index}
      id={`profile-${index}`}
      aria-labelledby={`profile-${index}`}
      {...other}
    >
      {value === index && <Box sx={{ p: 3 }}>{children}</Box>}
    </div>
  );
}

const Profile = () => {
  const [tabValues, setTabValue] = useState<number>(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setTabValue(newValue);
  };

  const user = useSelector((state: RootState) => state.auth);

  const { data: dataStudent } = useGetStudentProfileQuery(user.accountID || '');

  return (
    <>
      <div className='container my-3'>
        <Card sx={{ maxWidth: '100%' }}>
          <CardMedia
            sx={{ height: 200 }}
            image='./background.jpg'
            title='green iguana'
          />
          <CardContent className='mx-5'>
            <Box
              className='mb-4'
              sx={{
                height: '100px',
                display: 'flex',
                justifyContent: { xs: 'center', md: 'flex-start' },
                alignItems: { xs: 'center', md: 'flex-start' }
              }}
            >
              <Box sx={{ marginTop: '-90px', width: '150px' }}>
                <Badge
                  count={
                    <div
                      style={{
                        borderRadius: '50%',
                        backgroundColor: 'gray',
                        width: '30px',
                        height: '30px',
                        padding: '3px'
                      }}
                      className='d-flex justify-content-center align-items-center'
                    >
                      <FaPen
                        style={{ color: 'white', cursor: 'pointer' }}
                        // onClick={() => setModalChangeAvatar(true)}
                      />
                    </div>
                  }
                  offset={[-9, 125]}
                >
                  <Avatar
                    sx={{ width: '150px', height: '150px', marginBottom: '20px' }}
                    src={dataStudent?.image}
                  />
                </Badge>
                <Typography
                  sx={{
                    textAlign: 'center',
                    fontWeight: 'bold',
                    fontSize: '20px',
                    whiteSpace: 'nowrap',
                    overflow: 'hidden',
                    textOverflow: 'ellipsis'
                  }}
                >
                  {dataStudent?.fullName}
                </Typography>
              </Box>
            </Box>

            <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
              <Tabs
                value={tabValues}
                onChange={handleChange}
                aria-label='basic tabs example'
              >
                <Tab
                  label='Thông tin cá nhân'
                  id='profile-0'
                />
                <Tab
                  label='Bảo mật'
                  id='profile-1'
                />
              </Tabs>
            </Box>
            <CustomTabPanel
              value={tabValues}
              index={0}
            >
              <Personal />
            </CustomTabPanel>
            <CustomTabPanel
              value={tabValues}
              index={1}
            >
              Item Two
            </CustomTabPanel>
          </CardContent>

          <CardActions className='mx-5'></CardActions>
        </Card>
      </div>
    </>
  );
};

export default Profile;
