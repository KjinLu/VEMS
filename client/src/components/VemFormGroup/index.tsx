import { FormGroup, FormGroupProps } from 'reactstrap';

const VemFromGroup = ({ ...restProps }: FormGroupProps) => {
  return (
    <>
      <FormGroup row>{restProps.children}</FormGroup>
    </>
  );
};
export default VemFromGroup;
