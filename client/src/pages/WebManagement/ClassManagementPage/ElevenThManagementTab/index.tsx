import DataTable from 'react-data-table-component';

import NoRecord from '@/components/NoRecord';
import VemsLoader from '@/components/VemsLoader';
import { ClassIndex } from '../type';
import { classColumn } from '../data-table-column';

const ElevenThManagementTab = () => {
  const classes: ClassIndex[] = [
    { id: '1', class: '11A1', teacher: 'Nguyễn Văn A', amount: '50' },
    { id: '2', class: '11A2', teacher: 'Nguyễn Văn B', amount: '38' },
    { id: '3', class: '11A3', teacher: 'Nguyễn Văn C', amount: '32' },
    { id: '4', class: '11A4', teacher: 'Nguyễn Văn D', amount: '30' },
    { id: '5', class: '11A5', teacher: 'Nguyễn Văn E', amount: '52' },
    { id: '6', class: '11A6', teacher: 'Nguyễn Văn F', amount: '58' }
  ];

  return (
    <>
      <DataTable
        data={classes}
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
