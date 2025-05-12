export const formatDate = (date: string | Date, format: string = 'yyyy-MM-dd') => {
    if (!date) return '';
    const dateObj = new Date(date);
    
    // Define format patterns
    const formatPatterns = {
        'yyyy': dateObj.getFullYear(),
        'MM': String(dateObj.getMonth() + 1).padStart(2, '0'),
        'dd': String(dateObj.getDate()).padStart(2, '0'),
        'HH': String(dateObj.getHours()).padStart(2, '0'),
        'mm': String(dateObj.getMinutes()).padStart(2, '0'),
        'ss': String(dateObj.getSeconds()).padStart(2, '0')
    };
    
    // Replace format patterns in the format string
    let formattedDate = format;
    for (const [pattern, value] of Object.entries(formatPatterns)) {
        formattedDate = formattedDate.replace(pattern, String(value));
    }
    
    return formattedDate;
}