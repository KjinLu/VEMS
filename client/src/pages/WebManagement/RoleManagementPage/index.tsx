import { Box, Tab, Tabs } from '@mui/material';
import { useState } from 'react';
import RoleList from './_components';
import AccountRole from './_components/RoleAccount';

function CustomTabPanel(props: any) {
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

const RoleManagementPage = () => {
  const [tabValues, setTabValue] = useState<number>(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setTabValue(newValue);
  };

  return (
    <>
      <Box sx={{ px: 2, pb: 3 }}>
        <h3>Quản lý quyền</h3>
      </Box>
      <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <Tabs
          value={tabValues}
          onChange={handleChange}
          aria-label='basic tabs example'
        >
          <Tab
            label='Quyền'
            // {...a11yProps(0)}
          />
          <Tab
            label='Tài khoản'
            // {...a11yProps(1)}
          />
        </Tabs>
      </Box>
      <CustomTabPanel
        value={tabValues}
        index={0}
      >
        <RoleList />
      </CustomTabPanel>
      <CustomTabPanel
        value={tabValues}
        index={1}
      >
        <AccountRole />
      </CustomTabPanel>
    </>
  );
};

export default RoleManagementPage;
