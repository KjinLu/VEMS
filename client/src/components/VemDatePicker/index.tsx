import React from 'react';
import {
  TextField,
  InputAdornment,
  FilledTextFieldProps,
  OutlinedTextFieldProps,
  StandardTextFieldProps,
  TextFieldVariants
} from '@mui/material';
import { CalendarToday } from '@mui/icons-material';
import { JSX } from 'react/jsx-runtime';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import dayjs from 'dayjs';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';

interface VemDatePickerProps {
  name?: string;
  id: string;
  label?: string;
  placeholder?: string;
  defaultValue?: Date;
  value?: Date;
  onChange?: (date: Date | null) => void;
  required?: boolean;
  disabled?: boolean;
  fullWidth?: boolean;
  className?: string;
  style?: React.CSSProperties;
}

const VemDatePicker: React.FC<VemDatePickerProps> = ({
  name,
  id,
  label,
  placeholder,
  defaultValue,
  value,
  onChange,
  required = false,
  disabled = false,
  fullWidth = true,
  className,
  style
}) => {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <DatePicker
        value={value ? dayjs(value) : null}
        onChange={date => onChange?.(date ? date.toDate() : null)}
        defaultValue={defaultValue ? dayjs(defaultValue) : null}
        slotProps={{
          textField: {
            id,
            label,
            placeholder,
            required,
            disabled,
            fullWidth,
            className,
            style
          }
        }}
      />
    </LocalizationProvider>
  );
};

export default VemDatePicker;
