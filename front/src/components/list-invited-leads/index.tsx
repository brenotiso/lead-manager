import {
  Avatar,
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  Typography
} from '@mui/material';
import dayjs from 'dayjs';
import { useEffect, useState } from 'react';
import { FiBriefcase, FiMapPin } from 'react-icons/fi';
import { api } from '../../services/api';
import { Lead } from '../../services/types/lead';

export const ListInvitedLeads = () => {
  const [leads, setLeads] = useState<Lead[]>([]);

  useEffect(() => {
    api
      .get('/leads?status=invited')
      .then(response => setLeads(response.data))
      .catch(err => {
        console.error('Erro' + err);
      });
  }, []);

  const handleAcceptLead = (id: string) => {
    api
      .put(`/leads/${id}`, { status: 1 })
      .then(() =>
        setLeads(oldValues => oldValues.filter(lead => lead.id !== id))
      )
      .catch(err => {
        console.error('Erro' + err);
      });
  };

  const handleDeclineLead = (id: string) => {
    api
      .put(`/leads/${id}`, { status: 2 })
      .then(() =>
        setLeads(oldValues => oldValues.filter(lead => lead.id !== id))
      )
      .catch(err => {
        console.error('Erro' + err);
      });
  };

  return (
    <>
      {leads.map(lead => (
        <Card sx={{ width: '100%' }} key={lead.id}>
          <CardHeader
            avatar={
              <Avatar sx={{ bgcolor: 'primary.main' }}>
                {lead.contact.firstName[0]}
              </Avatar>
            }
            title={
              <Typography fontWeight={600}>{lead.contact.firstName}</Typography>
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
            </Grid>

            <Box sx={{ padding: '10px 0px' }}>
              <Divider />
            </Box>

            {lead.description}
          </CardContent>

          <Divider />

          <CardActions sx={{ color: 'text.secondary' }}>
            <Button
              variant="contained"
              color="secondary"
              onClick={() => handleAcceptLead(lead.id)}
            >
              Accept
            </Button>
            <Button
              variant="contained"
              color="inherit"
              onClick={() => handleDeclineLead(lead.id)}
            >
              Decline
            </Button>
            <Box sx={{ paddingLeft: '18px' }}>
              <b>${lead.price}</b> Lead Invitation
            </Box>
          </CardActions>
        </Card>
      ))}
    </>
  );
};
