import DataTable from 'react-data-table-component';

import NoRecord from '@/components/NoRecord';
import VemsLoader from '@/components/VemsLoader';
import { ClassIndex, ClassListProps } from '../type';
import { classColumn } from '../data-table-column';

const ElevenThManagementTab = ({ data }: ClassListProps) => {
  return (
    <>
      <DataTable
        data={data}
        columns={classColumn}
        striped={true}
        highlightOnHover={true}
        persistTableHead
        pagination
        paginationComponentOptions={{
          rowsPerPageText: 'Số dòng trên trang'
        }}
        paginationServer
        noDataComponent={<NoRecord />}
        progressComponent={<VemsLoader />}
      />
    </>
  );
};

export default ElevenThManagementTab;
