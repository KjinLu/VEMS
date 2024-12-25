import * as XLSX from 'xlsx';

function normalize(str1: string, str2: string): boolean {
  const normalizeVietnamese = (str: string) => str.normalize('NFC').toLowerCase();
  return normalizeVietnamese(str1) === normalizeVietnamese(str2);
}

const validationSubject = async (
  file: File,
  keywords: string[],
  numberOfClass?: number,
  sheetName?: string
): Promise<string[]> => {
  // ): Promise<void> => {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();

    reader.onload = event => {
      sheetName = sheetName || 'TKB-Student';
      try {
        const data = event.target?.result;
        if (!data) {
          reject('File sai định dạng');
          return;
        }

        const workbook = XLSX.read(data, { type: 'array' });

        if (!workbook.SheetNames.includes(sheetName)) {
          reject(`Sheet "${sheetName}" không tồn tại trong file.`);
          return;
        }

        const worksheet = workbook.Sheets[sheetName];
        const positions: string[] = [];

        numberOfClass = numberOfClass || 1;

        const ranges: {
          start: { col: string; row: number } | { col: string; row: number };
          end: { col: string; row: number } | { col: string; row: number };
        }[] = [];

        for (let i = 1; i <= numberOfClass; i++) {
          ranges.push({
            start: { col: 'D', row: 4 + (i - 1) * 14 },
            end: { col: 'I', row: 8 + (i - 1) * 14 }
          });

          ranges.push({
            start: { col: 'D', row: 10 + (i - 1) * 14 },
            end: { col: 'I', row: 14 + (i - 1) * 14 }
          });
        }

        // const ranges = [
        //   { start: { col: 'D', row: 4 }, end: { col: 'I', row: 8 } },
        //   { start: { col: 'D', row: 10 }, end: { col: 'I', row: 14 } }
        // ];

        const isCellInRange = (cellAddress: string): boolean => {
          const match = cellAddress.match(/^([A-Z]+)(\d+)$/);
          if (!match) return false;

          const [_, col, row] = match;
          const rowIndex = parseInt(row, 10);

          return ranges.some(({ start, end }) => {
            return (
              col >= start.col &&
              col <= end.col &&
              rowIndex >= start.row &&
              rowIndex <= end.row
            );
          });
        };

        Object.keys(worksheet).forEach(cellAddress => {
          if (cellAddress.startsWith('!')) return;

          if (isCellInRange(cellAddress)) {
            const cell = worksheet[cellAddress];
            if (cell && cell.v && typeof cell.v === 'string') {
              const valueOfCell = cell.v.trim();

              if (!keywords.some(keyword => normalize(valueOfCell, keyword))) {
                positions.push(`${cellAddress}: "${valueOfCell}"`);
              }
            }
          }
        });

        if (positions.length > 0) {
          const blob = new Blob([positions.join('\n')], { type: 'text/plain' });
          const url = URL.createObjectURL(blob);
          const link = document.createElement('a');
          link.href = url;
          link.download = 'errors.txt';
          link.click();
          URL.revokeObjectURL(url);
        }

        resolve(positions);
      } catch (error) {
        reject(`File sai định dạng: ${error}`);
      }
    };

    reader.onerror = () => {
      reject('Không thể đọc file');
    };

    reader.readAsArrayBuffer(file);
  });
};

export default validationSubject;
