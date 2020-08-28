import { MatPaginatorIntl } from '@angular/material/paginator';
import { TranslateParser, TranslateService } from '@ngx-translate/core';

export class CustomPaginator extends MatPaginatorIntl {

    private rangeLabelIntl: string;

    constructor(
        private translateService: TranslateService,
        private translateParser: TranslateParser) {
        super();
        this.getTranslations();
        this.translateService.onLangChange.subscribe(() => this.getTranslations());
    }
    getTranslations() {
        this.translateService
            .get(['PAGINATOR.ITEMS_PER_PAGE_LABEL', 'PAGINATOR.NEXT_PAGE_LABEL', 'PAGINATOR.PREVIOUS_PAGE_LABEL',
            'PAGINATOR.FIRST_PAGE_LABEL', 'PAGINATOR.LAST_PAGE_LABEL', 'PAGINATOR.RANGE_PAGE_LABEL_2'])
            .subscribe(translation => {
                this.itemsPerPageLabel = translation['PAGINATOR.ITEMS_PER_PAGE_LABEL'];
                this.nextPageLabel = translation['PAGINATOR.NEXT_PAGE_LABEL'];
                this.previousPageLabel = translation['PAGINATOR.PREVIOUS_PAGE_LABEL'];
                this.firstPageLabel = translation['PAGINATOR.FIRST_PAGE_LABEL'];
                this.lastPageLabel = translation['PAGINATOR.LAST_PAGE_LABEL'];
                this.rangeLabelIntl = translation['PAGINATOR.RANGE_PAGE_LABEL_2'];
                this.changes.next();
            });
    }
    getRangeLabel = (page, pageSize, length) => {
        length = Math.max(length, 0);
        const startIndex = page * pageSize;
        const endIndex =
            startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
        return this.translateParser.interpolate(this.rangeLabelIntl, { startIndex, endIndex, length });
    }
}
