import empty from '@assets/empty.png';

const NoRecord = () => {
  return (
    <div style={{ background: 'none', padding: '24px 0', textAlign: 'center' }}>
      <img
        style={{ width: '120px' }}
        src={empty}
      />
      <p style={{ color: '#AAA', fontWeight: 300, fontSize: '12px' }}>Không có dữ liệu</p>
    </div>
  );
};

export default NoRecord;
