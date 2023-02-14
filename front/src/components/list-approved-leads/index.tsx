import {
  Avatar,
  Box,
  Card,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  Link,
  Typography
} from '@mui/material';
import dayjs from 'dayjs';
import { useEffect, useState } from 'react';
import { FiBriefcase, FiMail, FiMapPin, FiPhone } from 'react-icons/fi';
import { api } from '../../services/api';
import { Lead } from '../../services/types/lead';

export const ListApprovedLeads = () => {
  const [leads, setLeads] = useState<Lead[]>([]);

  useEffect(() => {
    api
      .get('/leads?status=accepted')
      .then(response => setLeads(response.data))
      .catch(err => {
        console.error('Erro' + err);
      });
  }, []);

  return (
    <>
      {leads.map(lead => (
        <Card sx={{ width: '100%', marginBottom: '12px' }} key={lead.id}>
          <CardHeader
            avatar={
              <Avatar sx={{ bgcolor: 'primary.main' }}>
                {lead.contact.firstName[0]}
              </Avatar>
            }
            title={
              <Typography
                fontWeight={600}
              >{`${lead.contact.firstName} ${lead.contact.lastName}`}</Typography>
            }
            subheader={dayjs(lead.createdAt).format('MMMM D @ h:mm a')}
          />

          <Divider />

          <CardContent sx={{ color: 'text.secondary' }}>
            <Grid container alignItems="center" spacing={2}>
              <Grid item xs="auto" container alignItems="center" spacing={1}>
                <Grid item>
                  <FiMapPin size={16} />
                </Grid>
                <Grid item>{lead.suburb}</Grid>
              </Grid>
              <Grid item xs="auto" container alignItems="center" spacing={1}>
                <Grid item>
                  <FiBriefcase size={16} />
                </Grid>
                <Grid item>{lead.category}</Grid>
              </Grid>
              <Grid item xs="auto">
                JOB ID: {lead.jobId}
              </Grid>
              <Grid item xs="auto">
                <b>${lead.acceptedPrice}</b> Lead Invitation
              </Grid>
            </Grid>

            <Box sx={{ padding: '10px 0px' }}>
              <Divider />
            </Box>

            <Grid
              container
              alignItems="center"
              spacing={2}
              sx={{ paddingBottom: '10px' }}
            >
              <Grid item xs="auto" container alignItems="center" spacing={1}>
                <Grid item>
                  <FiPhone size={16} />
                </Grid>
                <Grid item>
                  <Link href="tel:123456789" underline="hover">
                    {lead.contact.phoneNumber}
                  </Link>
                </Grid>
              </Grid>
              <Grid item xs="auto" container alignItems="center" spacing={1}>
                <Grid item>
                  <FiMail size={16} />
                </Grid>
                <Grid item>
                  <Link href="mailto:email@teste.com" underline="hover">
                    {lead.contact.email}
                  </Link>
                </Grid>
              </Grid>
            </Grid>
            {lead.description}
          </CardContent>
        </Card>
      ))}
    </>
  );
};
