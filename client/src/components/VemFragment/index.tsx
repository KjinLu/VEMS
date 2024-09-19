import { Fragment } from 'react';

const VemFragment = (props: any) => {
  return <Fragment key={props.key}>{props.children}</Fragment>;
};
export default VemFragment;
