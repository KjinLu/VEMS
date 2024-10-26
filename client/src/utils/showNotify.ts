import { toast } from 'react-toastify';

export const ShowNotify = ({
  statusCode,
  messageSuccess,
  messageError,
  OnReLoad,
  message,
  type
}: {
  statusCode: boolean;
  messageSuccess?: string;
  messageError?: string;
  OnReLoad?: () => void;
  message?: string;
  type?: 'success' | 'error' | 'warning' | 'info';
}) => {
  if (type === undefined) {
    if (statusCode) {
      toast.success(messageSuccess);
      if (OnReLoad) {
        OnReLoad();
      }
    } else {
      toast.error(messageError);
    }
  } else {
    toast[type](message);
  }
};
