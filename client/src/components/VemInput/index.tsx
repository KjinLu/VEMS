import { useEffect, useState } from 'react';
import React from 'react';
import { TextField, InputAdornment, IconButton, InputBaseProps } from '@mui/material';
import { Visibility, VisibilityOff } from '@mui/icons-material';

interface VemInputTypes extends Omit<InputBaseProps, 'prefix'> {
  name?: string;
  id: string;
  label?: string;
  placeholder?: string;
  size?: 'small' | 'medium';
  type?:
    | 'text'
    | 'password'
    | 'email'
    | 'number'
    | 'checkbox'
    | 'radio'
    | 'date'
    | 'time';
  prefix?: string | React.ReactNode;
  suffix?: string | React.ReactNode;
  autoComplete?: 'on' | 'off';

  required?: boolean;
  disabled?: boolean;
  errors?: boolean;
  fullWidth?: boolean;
  variant?: 'standard' | 'outlined' | 'filled';

  defaultValue?: any;
  onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
  value?: any;

  className?: string;
  style?: React.CSSProperties;
}

const VemInput = ({
  name,
  id,
  label = '',
  placeholder = '',
  size = 'medium',
  type = 'text',
  prefix,
  suffix,
  autoComplete = 'off',
  required = false,
  disabled = false,
  errors = false,
  fullWidth = true,
  variant = 'standard',
  onChange,
  value,
  className,
  style
}: VemInputTypes) => {
  const [showPassword, setShowPassword] = useState<boolean>(false);

  return (
    <>
      {type === 'password' ? (
        <TextField
          id={id}
          label={label}
          placeholder={placeholder}
          size={size}
          type={showPassword ? 'text' : 'password'}
          InputProps={{
            startAdornment: prefix && (
              <InputAdornment position='start'>{prefix}</InputAdornment>
            ),
            endAdornment: (
              <InputAdornment position='end'>
                <IconButton
                  onClick={() => setShowPassword(!showPassword)}
                  edge='end'
                  style={{ marginRight: '0' }}
                >
                  {showPassword ? <Visibility /> : <VisibilityOff />}
                </IconButton>
              </InputAdornment>
            )
          }}
          required={required}
          disabled={disabled}
          error={errors}
          fullWidth={fullWidth}
          variant={variant}
          onChange={onChange}
          value={value}
          className={`custom-components ${className}`}
          style={style}
          autoComplete={autoComplete}
        />
      ) : (
        <TextField
          id={id}
          InputLabelProps={{
            shrink: !!value || undefined
          }}
          label={label}
          placeholder={placeholder}
          size={size}
          type={type}
          // InputProps={{
          //   startAdornment: prefix && (
          //     <InputAdornment position='start'>{prefix}</InputAdornment>
          //   ),
          //   endAdornment: suffix && (
          //     <InputAdornment position='end'>{suffix}</InputAdornment>
          //   )
          // }}
          required={required}
          disabled={disabled}
          error={errors}
          fullWidth={fullWidth}
          variant={variant}
          value={value ?? ''}
          onChange={onChange}
          className={`custom-components ${className}`}
          style={style}
          autoComplete={autoComplete}
        />
      )}
    </>
  );
};

export default VemInput;
