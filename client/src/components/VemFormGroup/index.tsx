import { FormGroup, FormGroupProps } from 'reactstrap';

const VemFromGroup = ({ children, ...restProps }: FormGroupProps) => {
  return (
    <>
      <FormGroup
        row
        {...restProps}
      >
        {children}
      </FormGroup>
    </>
  );
};
export default VemFromGroup;
