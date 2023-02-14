import { TabContext, TabList, TabPanel } from '@mui/lab';
import { Box, styled, Tab } from '@mui/material';
import { SyntheticEvent, useState } from 'react';
import { ListApprovedLeads } from '../../components/list-approved-leads';
import { ListInvitedLeads } from '../../components/list-invited-leads';

interface StyledTabProps {
  label: string;
  value: string;
}

const CustomTab = styled((props: StyledTabProps) => (
  <Tab disableRipple {...props} />
))(({ theme }) => ({
  textTransform: 'none',
  backgroundColor: 'white',
  fontWeight: theme.typography.fontWeightRegular,
  width: '100%',
  color: 'rgba(0, 0, 0, 0.85)',
  fontSize: '16px',
  border: '1px solid #EEEEEE',
  '&.Mui-selected': {
    color: 'black',
    fontWeight: theme.typography.fontWeightMedium
  }
}));

export const Leads = () => {
  const [value, setValue] = useState('invited');

  return (
    <Box sx={{ width: '100%', display: 'flex', justifyContent: 'center' }}>
      <Box sx={{ width: 800 }}>
        <TabContext value={value}>
          <Box sx={{ border: 1, borderColor: 'divider' }}>
            <TabList
              onChange={(_: SyntheticEvent, newValue: string) =>
                setValue(newValue)
              }
              centered
              variant="fullWidth"
            >
              <CustomTab label="Invited" value="invited" />
              <CustomTab label="Accepted" value="accepted" />
            </TabList>
          </Box>

          <TabPanel value="invited" sx={{ padding: '24px 0px 0px 0px' }}>
            <ListInvitedLeads />
          </TabPanel>

          <TabPanel value="accepted" sx={{ padding: '24px 0px 0px 0px' }}>
            <ListApprovedLeads />
          </TabPanel>
        </TabContext>
      </Box>
    </Box>
  );
};
