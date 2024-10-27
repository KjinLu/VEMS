import {
  Avatar,
  Box,
  Card,
  CardContent,
  CardMedia,
  Tab,
  Tabs,
  Typography
} from '@mui/material';
import { FaPen } from 'react-icons/fa';
import React, { useEffect, useState } from 'react';
import Personal from './components/personal';
import { Badge, Tag } from 'antd';
import {
  IProfileSimple,
  useGetProfileSimple
} from '@/hooks/profileSimple/useGetProfileSimple';
import ChangeAvatar from './components/changeAvatar';
import ResetPassword from './components/password';
import AvatarDefault from '@/assets/images/personal/avatarDefault.jpg';

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

  const { getProfile, isLoading } = useGetProfileSimple();
  const [profile, setProfile] = useState<IProfileSimple | null>(null);

  const [modalChangeAvatar, setModalChangeAvatar] = useState<boolean>(false);

  useEffect(() => {
    const fetchProfile = async () => {
      const profileData = getProfile();
      setProfile(profileData);
    };

    fetchProfile();
  }, [getProfile]);

  return (
    <>
      <div className='container my-3'>
        <Card sx={{ maxWidth: '100%' }}>
          <CardMedia
            sx={{ height: 200 }}
            image='./background.jpg'
            title='green iguana'
          />
          <CardContent
            className='mx-xl-5'
            // sx={{ paddingBottom: '0 !important' }}
          >
            <Box
              className='mb-4'
              sx={{
                height: '100px',
                display: 'flex',
                justifyContent: { xs: 'center', md: 'flex-start' },
                alignItems: { xs: 'center', md: 'flex-start' },
                flexDirection: 'row',
                padding: '5px'
              }}
            >
              <Box
                sx={{
                  marginTop: '-60px',
                  width: '150px',
                  display: { xs: 'block', md: 'flex' },
                  gap: '25px',
                  alignItems: 'center'
                }}
              >
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
                        onClick={() => setModalChangeAvatar(true)}
                      />
                    </div>
                  }
                  offset={[-15, 125]}
                >
                  <Avatar
                    sx={{
                      width: '150px',
                      height: '150px',
                      marginBottom: '10px',
                      border: '4px solid #fff',
                      cursor: 'pointer'
                    }}
                    onClick={() => setModalChangeAvatar(true)}
                    src={
                      profile?.image && profile.image != ''
                        ? profile.image
                        : AvatarDefault
                    }
                  />
                </Badge>

                <ChangeAvatar
                  isOpen={modalChangeAvatar}
                  onClose={() => setModalChangeAvatar(false)}
                  onReload={() => getProfile()}
                  imageDefault={profile?.image ?? AvatarDefault}
                />

                <Box sx={{ width: { xs: 'auto', md: '250px' } }}>
                  <Typography
                    sx={{
                      textAlign: 'center',
                      fontWeight: 'bold',
                      fontSize: '25px',
                      whiteSpace: 'nowrap',
                      overflow: 'hidden',
                      textOverflow: 'ellipsis'
                    }}
                    className={'title'}
                  >
                    {profile?.fullName}
                  </Typography>
                  <Box sx={{ textAlign: { xs: 'center', md: 'left' } }}>
                    <Tag color='success'>{profile?.typeName}</Tag>
                  </Box>
                </Box>
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
              <ResetPassword />
            </CustomTabPanel>
          </CardContent>

          {/* <CardActions className='mx-5'></CardActions> */}
        </Card>
      </div>
    </>
  );
};

export default Profile;
