import { StateManagerProps } from 'node_modules/react-select/dist/declarations/src/useStateManager';
import { forwardRef } from 'react';
import Select from 'react-select';
import CreatableSelect from 'react-select/creatable';
import ClipLoader from 'react-spinners/ClipLoader';

interface VemsSelectTypes extends StateManagerProps {
  isCreatable?: boolean;
  isLoading?: boolean;
}

const VemsSelect = forwardRef<HTMLDivElement, VemsSelectTypes>(
  ({ isCreatable = false, isLoading = false, ...props }, ref) => {
    const customStyles = {
      control: (base: any, state: any) => ({
        ...base,
        borderWidth: '1px',
        borderRadius: '7px',
        borderColor: state.isFocused ? '#98b9c8' : '#cccccc',
        boxShadow: state.isFocused ? '0 0 0 0.25rem #bbdeee' : 'none',
        '&:hover': {
          borderColor: '#bbdeee',
          boxShadow: '0 0 0 0.25rem #bbdeee'
        },
        cursor: 'pointer',
        fontSize: '16px'
      }),
      option: (base: any, state: any) => ({
        ...base,
        backgroundColor:
          (state.isSelected ? '#61b2db' : '') || state.isFocused ? '#61b2db' : '',
        cursor: 'pointer'
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
              zIndex: 99
            }}
          >
            <ClipLoader
              color='#1976d2'
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

export default VemsSelect;
