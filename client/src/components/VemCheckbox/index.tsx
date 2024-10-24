import { ReactNode } from 'react';
import { Checkbox } from '@mui/material';

interface VemCheckboxProps {
  color?: 'inherit' | 'primary' | 'secondary' | 'success' | 'warning' | 'info' | 'error';
  disabled?: boolean;
  fullWidth?: boolean;
  size?: 'small' | 'medium' | 'large';
  onChange?: (event: React.ChangeEvent<HTMLInputElement>, checked: boolean) => void;

  checked: boolean;
  checkedIcon: ReactNode;

  className?: string;
  style?: React.CSSProperties;
}

const VemCheckbox = ({
  color = 'primary',
  className,
  disabled = false,
  fullWidth,
  size = 'small',
  onChange,
  checked = false,
  checkedIcon = undefined,
  ...restProps
}: VemCheckboxProps) => {
  return (
    <Checkbox
      className={className}
      disabled={disabled}
      onChange={onChange}
      // checked={checked}
      // checkedIcon={checkedIcon ? <>{checkedIcon}</> : undefined}
      // icon={<Checkbox />}
      sx={{ '& .MuiSvgIcon-root': { fontSize: 24 } }}
      {...restProps}
    />
  );
};

export default VemCheckbox;
