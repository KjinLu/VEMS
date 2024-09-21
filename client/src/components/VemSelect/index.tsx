import { forwardRef } from 'react';
import Select, { Props as StateManagerProps } from 'react-select';
import CreatableSelect from 'react-select/creatable';

import ClipLoader from 'react-spinners/ClipLoader';

interface VemSelectTypes extends StateManagerProps {
  isCreatable?: boolean;
  isLoading?: boolean;
}

const VemSelect = forwardRef<HTMLDivElement, VemSelectTypes>(
  ({ isCreatable = false, isLoading = false, ...props }, ref) => {
    const customStyles = {
      control: (base: any, state: any) => ({
        ...base,
        borderWidth: '1px',
        borderRadius: '7px',
        borderColor: state.isFocused ? '#387562' : '#cccccc',
        boxShadow: state.isFocused ? '0 0 0 0.25rem #3875623b' : 'none',
        '&:hover': {
          borderColor: '#387562',
          boxShadow: '0 0 0 0.25rem #77b26726'
        }
      }),
      option: (base: any, state: any) => ({
        ...base,
        backgroundColor: state.isSelected
          ? '#79B668'
          : '' || state.isFocused
            ? '#77b26726'
            : ''
      })
    };

    return (
      <div
        style={{ position: 'relative' }}
        ref={ref}
      >
        {isLoading && (
          <div
            style={{
              position: 'absolute',
              top: '60%',
              right: '30px',
              transform: 'translate(-50%, -50%)',
              zIndex: 1
            }}
          >
            <ClipLoader
              color='var(--primary)'
              size={24}
            />
          </div>
        )}
        {isCreatable ? (
          <CreatableSelect
            isClearable
            styles={customStyles}
            isDisabled={isLoading}
            {...props}
          />
        ) : (
          <Select
            styles={customStyles}
            isDisabled={isLoading}
            {...props}
          />
        )}
      </div>
    );
  }
);

export default VemSelect;
